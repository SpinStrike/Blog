namespace Blog.Models
{
    public class AuthorizeModelWrapper : ModelWrapper<AuthorizeModel>
    {
        public AuthorizeModelWrapper()
        {
            MainContent = new AuthorizeModel();
        }
    }
}