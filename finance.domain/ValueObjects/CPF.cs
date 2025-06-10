namespace backend.finance.domain.ValueObjects
{
    public class CPF
    {
        public string Number { get; private set; } = string.Empty;
        public CPF()
        {
        }
        public CPF(string value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid CPF format.", nameof(value));
            }
            Number = value;
        }
        public bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;
           
            return true;
        }
        public override string ToString()
        {
            return Number;
        }
        public static implicit operator string(CPF cpf)
        {
            return cpf.Number;
        }
    }
}
