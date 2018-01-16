namespace Blog.Models
{
    public class RegistrationModelWrapper : ModelWrapper<RegistrationModel>
    {
        public RegistrationModelWrapper()
        {
            MainContent = new RegistrationModel();
        }
    }
}