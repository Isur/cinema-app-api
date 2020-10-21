using cinema_app_api.Models;

namespace cinema_app_api.Helpers {
    public static class RoleHelper {
        public static string RoleToString(Roles roles) {
            switch(roles) {
                case Roles.ADMIN:
                    return "Admin";
                case Roles.WORKER:
                    return "Worker";
                case Roles.USER:
                    return "User";
                default:
                    return "User";
            }
        }
    }
}