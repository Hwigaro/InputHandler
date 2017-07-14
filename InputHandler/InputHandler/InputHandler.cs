using System.Runtime.InteropServices;
using static InputHandler.WinApi;

namespace InputHandler
{
    public class InputHandler
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        /// <summary>
        /// Send a key down and hold it down until sendkeyup method is called
        /// </summary>
        /// <param name="keyCode"></param>
        public static void SendKeyDown(KeyCode keyCode)
        {
            INPUT[] InputData = new INPUT[1];
            InputData[0].Type = 1;
            InputData[0].Data.Keyboard.Vk = (ushort)keyCode;
            InputData[0].Data.Keyboard.Time = 0;
            InputData[0].Data.Keyboard.Flags = 0;
            SendInput((uint)InputData.Length, InputData, Marshal.SizeOf(typeof(INPUT)));
        }

        /// <summary>
        /// Release a key that is being hold down
        /// </summary>
        /// <param name="keyCode"></param>
        public static void SendKeyUp(KeyCode keyCode)
        {
            INPUT[] InputData = new INPUT[1];
            InputData[0].Type = 1;
            InputData[0].Data.Keyboard.Vk = (ushort)keyCode;
            InputData[0].Data.Keyboard.Time = 0;
            InputData[0].Data.Keyboard.Flags = 0x0002;
            SendInput((uint)InputData.Length, InputData, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void moveMouse(POINT target)
        {
            INPUT[] InputData = new INPUT[1];
            InputData[0].Type = 0;
            InputData[0].Data.Mouse.X = CalculateAbsoluteCoordinateX(target.X);
            InputData[0].Data.Mouse.Y = CalculateAbsoluteCoordinateY(target.Y);
            InputData[0].Data.Mouse.Flags = (uint)MouseEventFlags.MOUSEEVENTF_ABSOLUTE | (uint)MouseEventFlags.MOUSEEVENTF_MOVE;
            InputData[0].Data.Mouse.MouseData = 0;
            InputData[0].Data.Mouse.Time = 0;
            SendInput((uint)InputData.Length, InputData, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void SendLeftDown()
        {
            INPUT[] InputData = new INPUT[1];
            InputData[0].Type = 0;
            InputData[0].Data.Mouse.Flags = (uint)MouseEventFlags.MOUSEEVENTF_ABSOLUTE | (uint)MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
            InputData[0].Data.Mouse.MouseData = 0;
            InputData[0].Data.Mouse.Time = 0;
            SendInput((uint)InputData.Length, InputData, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void SendLeftUp()
        {
            INPUT[] InputData = new INPUT[1];
            InputData[0].Type = 0;
            InputData[0].Data.Mouse.Flags = (uint)MouseEventFlags.MOUSEEVENTF_ABSOLUTE | (uint)MouseEventFlags.MOUSEEVENTF_LEFTUP;
            InputData[0].Data.Mouse.MouseData = 0;
            InputData[0].Data.Mouse.Time = 0;
            SendInput((uint)InputData.Length, InputData, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void SendRightDown()
        {
            INPUT[] InputData = new INPUT[1];
            InputData[0].Type = 0;
            InputData[0].Data.Mouse.Flags = (uint)MouseEventFlags.MOUSEEVENTF_ABSOLUTE | (uint)MouseEventFlags.MOUSEEVENTF_RIGHTDOWN;
            InputData[0].Data.Mouse.MouseData = 0;
            InputData[0].Data.Mouse.Time = 0;
            SendInput((uint)InputData.Length, InputData, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void SendRightUp()
        {
            INPUT[] InputData = new INPUT[1];
            InputData[0].Type = 0;
            InputData[0].Data.Mouse.Flags = (uint)MouseEventFlags.MOUSEEVENTF_ABSOLUTE | (uint)MouseEventFlags.MOUSEEVENTF_RIGHTUP;
            InputData[0].Data.Mouse.MouseData = 0;
            InputData[0].Data.Mouse.Time = 0;
            SendInput((uint)InputData.Length, InputData, Marshal.SizeOf(typeof(INPUT)));
        }
    }
}
