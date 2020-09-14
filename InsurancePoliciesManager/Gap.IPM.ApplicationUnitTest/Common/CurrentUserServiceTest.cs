using Gap.IPM.Application.Common.Interfaces;

namespace Gap.IPM.ApplicationUnitTest.Common
{
    public class CurrentUserServiceTest: ICurrentUserService
    {
        public CurrentUserServiceTest()
        {
            UserId = "UserTest";
        }

        public string UserId { get; }
    }
}
