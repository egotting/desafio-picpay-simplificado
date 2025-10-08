using System.Text.RegularExpressions;

namespace desafio_picpay_simplificado.domain.model.Type;

public class CpfCnpj
{
    public string Value { get; }

    public CpfCnpj(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("CPF/CNPJ não pode ser vazio.", nameof(value));

        var digits = Regex.Replace(value, "[^0-9]", ""); // só números

        if (!IsCpf(digits) && !IsCnpj(digits))
            throw new ArgumentException("Documento inválido.", nameof(value));

        Value = digits;
    }

    public override string ToString() => Value;

    private static bool IsCpf(string input)
    {
        if (input.Length != 11) return false;
        if (new string(input[0], 11) == input) return false;

        int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var temp = input[..9];
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += (temp[i] - '0') * mult1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        var digito = resto.ToString();
        temp += digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (temp[i] - '0') * mult2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        digito += resto.ToString();

        return input.EndsWith(digito);
    }

    private static bool IsCnpj(string input)
    {
        if (input.Length != 14) return false;
        if (new string(input[0], 14) == input) return false;

        int[] mult1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var temp = input[..12];
        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += (temp[i] - '0') * mult1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        var digito = resto.ToString();
        temp += digito;

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += (temp[i] - '0') * mult2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        digito += resto.ToString();

        return input.EndsWith(digito);
    }

    public static implicit operator string(CpfCnpj cpfCnpj) => cpfCnpj.Value;
    public static implicit operator CpfCnpj(string value) => new(value);
}