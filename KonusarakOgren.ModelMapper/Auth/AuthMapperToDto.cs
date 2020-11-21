using KonusarakOgren.DTO.Auth;
using KonusarakOgren.Model.Auth;
using KonusarakOgren.Model.Auth.Response;

namespace KonusarakOgren.ModelMapper.Auth
{
    public static class AuthMapperToDto
    {
        public static RegisterRequestDto MaptoDto(this RegisterViewModel model)
        {
            if (model == null) return null;
            return new RegisterRequestDto()
            {
                Username = model.Username,
                Password = model.Password
            };
        }

        public static LoginRequestDto MapToDto(this LoginViewModel model)
        {
            if (model == null) return null;
            return new LoginRequestDto()
            {
                Password = model.Password,
                Username = model.Username
            };
        }
    }
}