namespace API_2__Bimestre.Models
{
    public class ValidacaoCPF
    {
        public static bool ValidaCPF(string cpf)
        {
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            if (cpf.Length > 11 || cpf.Length < 11)
            {
                return false;
            }

            int[] multi = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int multiplicacao = 0;

            for (int i = 0; i < cpf.Length - 2; i++)
            {
                multiplicacao += Convert.ToInt32(cpf[i].ToString()) * multi[i];
            }

            int digito1 = 0;
            if (multiplicacao % 11 < 2)
            {
                digito1 = 0;
            }

            else if (multiplicacao % 11 >= 2)
            {
                digito1 = 11 - (multiplicacao % 11);
            }


            int[] multi2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int multiplicacao2 = 0;

            for (int i = 0; i < cpf.Length - 1; i++)
            {
                multiplicacao2 += Convert.ToInt32(cpf[i].ToString()) * multi2[i];
            }

            int digito2 = 0;

            if (multiplicacao2 % 11 < 2)
            {
                digito2 = 0;
            }

            else if (multiplicacao2 % 11 >= 2)
            {
                digito2 = 11 - (multiplicacao2 % 11);
            }

            if (Convert.ToInt32(cpf[9].ToString()) == digito1 && Convert.ToInt32(cpf[10].ToString()) == digito2)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
