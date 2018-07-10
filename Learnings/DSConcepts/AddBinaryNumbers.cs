namespace DSConcepts
{
    public class AddBinaryNumbers
    {
        public string AddBinary(string a, string b)
        {
            string result = string.Empty;
            int carry = 0;
            for (int i = a.Length, j = b.Length; i > 0 || j > 0; i--, j--)
            {
                int n1 = (i > 0) ? a[i - 1] - '0' : 0;
                int n2 = (j > 0) ? b[j - 1] - '0' : 0;
                int val = (n1 + n2 + carry) % 2;
                carry = (n1 + n2 + carry) / 2;
                result = val.ToString() + result;
            }
            if (carry == 1)
                result = "1" + result;

            return result;
        }
    }
}
