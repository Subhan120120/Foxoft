using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Foxoft.AppCode
{
    /// <summary>
    /// Detects barcode-scanner input by measuring inter-keystroke timing.
    /// When a rapid burst of printable characters (followed by Enter) is detected
    /// within <see cref="MaxInterKeystrokeMs"/> ms, the class flags the input
    /// as coming from a scanner rather than manual keyboard entry.
    /// 
    /// Usage: call <see cref="ProcessKey"/> from a KeyDown handler.  
    /// If the method returns <c>true</c> the keystroke belongs to a barcode
    /// sequence and should be suppressed.
    /// 
    /// Once Enter is received at the end of a rapid burst, <see cref="BarcodeScanned"/>
    /// is raised with the complete barcode string.
    /// </summary>
    public sealed class BarcodeInputInterceptor
    {
        /// <summary>Maximum milliseconds allowed between consecutive barcode-scanner keystrokes.</summary>
        public int MaxInterKeystrokeMs { get; set; } = 50;

        /// <summary>Minimum number of characters to treat a rapid burst as a barcode.</summary>
        public int MinBarcodeLength { get; set; } = 4;

        /// <summary>Raised when a full barcode has been received (Enter pressed after rapid burst).</summary>
        public event Action<string> BarcodeScanned;

        private readonly StringBuilder _buffer = new();
        private readonly Stopwatch _sw = new();

        /// <summary>
        /// Feed a key event into the interceptor.
        /// </summary>
        /// <param name="e">The key event.</param>
        /// <returns>
        /// <c>true</c> if the key was recognised as part of a barcode burst and
        /// should be suppressed (set <c>e.Handled = true</c>);
        /// <c>false</c> if it looks like normal user input.
        /// </returns>
        public bool ProcessKey(KeyEventArgs e)
        {
            // Enter terminates a barcode burst
            if (e.KeyCode == Keys.Enter)
            {
                if (_buffer.Length >= MinBarcodeLength)
                {
                    string barcode = _buffer.ToString();
                    Reset();
                    BarcodeScanned?.Invoke(barcode);
                    return true; // suppress the Enter
                }

                Reset();
                return false;
            }

            // Only track printable characters (digits, letters, some punctuation)
            char ch = KeyToChar(e);
            if (ch == '\0')
            {
                // Non-printable key breaks a potential barcode sequence
                Reset();
                return false;
            }

            long elapsed = _sw.ElapsedMilliseconds;
            _sw.Restart();

            if (_buffer.Length == 0)
            {
                // First character – just start accumulating
                _buffer.Append(ch);
                return false; // don't suppress the first character yet
            }

            if (elapsed <= MaxInterKeystrokeMs)
            {
                // Rapid keystroke → likely scanner
                _buffer.Append(ch);
                return true; // suppress
            }

            // Too slow → reset; treat as normal typing
            Reset();
            _buffer.Append(ch);
            _sw.Restart();
            return false;
        }

        /// <summary>
        /// Returns <c>true</c> when the interceptor is currently accumulating a
        /// rapid burst that looks like a barcode scan.
        /// </summary>
        public bool IsAccumulating => _buffer.Length >= 2;

        /// <summary>Clears the internal buffer and timer.</summary>
        public void Reset()
        {
            _buffer.Clear();
            _sw.Reset();
        }

        // ── helpers ──────────────────────────────────────────────────────

        private static char KeyToChar(KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            // Digits 0-9
            if (key >= Keys.D0 && key <= Keys.D9)
                return (char)('0' + (key - Keys.D0));

            // Numpad digits
            if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
                return (char)('0' + (key - Keys.NumPad0));

            // Letters A-Z
            if (key >= Keys.A && key <= Keys.Z)
                return e.Shift ? (char)('A' + (key - Keys.A))
                               : (char)('a' + (key - Keys.A));

            // Common barcode-safe punctuation
            return key switch
            {
                Keys.OemMinus => '-',
                Keys.Oemplus => '+',
                Keys.OemPeriod => '.',
                Keys.Oemcomma => ',',
                Keys.Space => ' ',
                Keys.Oem1 => ';',       // semicolon
                Keys.Oem2 => '/',       // slash
                Keys.Oem5 => '\\',      // backslash
                _ => '\0'
            };
        }
    }
}
