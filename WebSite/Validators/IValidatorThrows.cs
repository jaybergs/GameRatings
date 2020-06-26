namespace WebSite.Validators
{
    public interface IValidatorThrows<T>
    {
        void ValidateThrow(T input);
    }
}