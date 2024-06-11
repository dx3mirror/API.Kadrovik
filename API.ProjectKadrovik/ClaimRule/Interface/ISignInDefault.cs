namespace API.ProjectKadrovik.ClaimRule.Interface
{
    public interface ISignInDefault
    {
        Task SignInAsync(HttpContext httpContext, string username);
    }
}
