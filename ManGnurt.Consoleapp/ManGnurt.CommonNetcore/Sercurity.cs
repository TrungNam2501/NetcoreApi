using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ManGnurt.CommonNetcore
{
    public static class Sercurity
    {
        // 1. Kiểm tra số nguyên hợp lệ
        public static bool IsValidInt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return int.TryParse(input.Trim(), out _);
        }

        // 2. Kiểm tra chuỗi hợp lệ (text)
        public static bool IsValidString(string input, int maxLength = 200)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            input = input.Trim();

            // Không cho phép toàn số
            if (int.TryParse(input, out _))
                return false;

            if (input.Length > maxLength)
                return false;

            return true;
        }

        // 3. Kiểm tra ký tự hợp lệ (chỉ chữ + số + khoảng trắng)
        private static readonly Regex SafeTextRegex =
            new Regex("^[a-zA-Z0-9 ]*$", RegexOptions.Compiled);

        public static bool HasNoSpecialCharacter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return SafeTextRegex.IsMatch(input);
        }

        // 4. Kiểm tra XSS cơ bản
        public static bool IsSafeFromXSS(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string lowerInput = input.Trim().ToLower();

            var dangerousList = new List<string>
        {
                "<applet",
            "<script", "<iframe", "<img", "<html", "<body",
            "<embed", "<object", "<link", "<style",
            "javascript:", "onerror", "onload",
            "&lt", "&gt"
        };

            foreach (var item in dangerousList)
            {
                if (lowerInput.Contains(item))
                    return false;
            }

            return true;
        }
    }
}
