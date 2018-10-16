namespace ApiUsuarios1.Model
{
    public interface IValidacao
    {
        void addError(string key, string errorMessage);
        bool isValid { get; }
    }
}
