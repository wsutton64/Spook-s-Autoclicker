using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static AutoClicker.Form1;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        // Initialize variables
        private const int F9_KEY = 120;
        private const int WH_KEYBOARD_LL = 13;
        private const int KEYUP = 0x0101;
        private List<RadioButton> radioButtons;
        private String currentMouseButton;
        private int delayTimer;
        private Boolean isActive = false;
        private IntPtr hookHandle = IntPtr.Zero;
        private LowLevelKeyboardProc hookCallback;

        // Enums
        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [Flags]
        public enum MouseEventFlags
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }

        // Structs
        [StructLayout(LayoutKind.Sequential)]
        public struct Input
        {
            public int type;
            public InputUnion inputUnion;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public MouseInput mouseInput;
            // Omitting KeyboardInput and HardwareInput for now...
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        // DLL import functions
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        /*
                [StructLayout(LayoutKind.Sequential)]
                public struct MousePoint
                {
                    public int X;
                    public int Y;

                    public MousePoint(int x, int y)
                    {
                        X = x;
                        Y = y;
                    }
                }
        */
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void SendInput(uint nInputs, Input[] pInputs, int cbSize);
        //        [DllImport("User32.Dll")]
        //        public static extern long SetCursorPos(int x, int y);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        /*/
         * 
         *Initialize application
         *
        /*/
        public Form1()
        {
            InitializeComponent();
        }
        // Create list of radio buttons and initialize keyboard hook when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButtons = new List<RadioButton>
            {
                leftRadioButton,
                midRadioButton,
                rightRadioButton
            };
            hookCallback = KeyboardEvent;
            hookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, hookCallback, IntPtr.Zero, 0);
        }
        // When the the button is clicked, run InitClicker()
        void ButtonClick(object sender, EventArgs e)
        {
            InitClicker();
        }
        // When the keyboard hook receives a key and the key is F9, run InitClicker();
        private IntPtr KeyboardEvent(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == F9_KEY)
                {
                    //Debug.WriteLine($"Key pressed: {(Keys)vkCode}");
                    InitClicker();
                }
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
        // Check which radio button is selected
        String RadioButtonCheck()
        {
            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    currentMouseButton = radioButton.Text;
                    return currentMouseButton;
                }
            }
            // Return left just as a default so the IDE stops yelling at me
            return leftRadioButton.Text;
        }
        // Using the selected radio button, set the corresponding MouseEventFlag
        uint GetMouseEventFlag()
        {
            switch (RadioButtonCheck()) // Both methods could probably be combined somehow but that is for later me at the moment. This works.
            {
                case "Middle":
                    return (uint) MouseEventFlags.MiddleDown | (uint) MouseEventFlags.MiddleUp;
                case "Right":
                    return (uint) MouseEventFlags.RightDown | (uint) MouseEventFlags.RightUp;
                default:
                    return (uint) MouseEventFlags.LeftDown | (uint) MouseEventFlags.LeftUp;
            }
        }
        // Initializes the autoclicker thread. Inverts isActive upon call and then runs corresponding functionality.
        void InitClicker()
        {
            isActive = !isActive;
            if (isActive)
            {
                delayInputBox.Enabled = false;
                Thread clickerThread = new Thread(RunClicker);
                clickerThread.Start();
                statusLabel.Text = "Running...";
            }
            else
            {
                delayInputBox.Enabled = true;
                statusLabel.Text = "Stopped";
            }
        }
        // Function for the autoclicker thread. Sends a mouse input once every delayTimer interval.
        void RunClicker()
        {
            Debug.WriteLine("RunClicker thread running!");
            delayTimer = (int) delayInputBox.Value;
            Input[] inputs = new Input[1];
            inputs[0].type = (int) InputType.Mouse;
            inputs[0].inputUnion.mouseInput.dwFlags = GetMouseEventFlag();
            while (isActive)
            {
                SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
                Thread.Sleep(delayTimer);
            }
            statusLabel.Text = "Stopped";
        }
    }
}
