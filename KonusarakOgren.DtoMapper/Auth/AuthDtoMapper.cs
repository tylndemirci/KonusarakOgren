using System;
using KonusarakOgren.DTO.Auth;
using Microsoft.AspNetCore.Identity;

namespace KonusarakOgren.DtoMapper.Auth
{
    public static class AuthDtoMapper
    {
        public static IdentityUser MapToEntity(this LoginRequestDto dto)
        {
            if (dto == null) return null;
            return new IdentityUser()
            {
                UserName = dto.Username,
            };
        }
        
        public static IdentityUser MapToEntity(this RegisterRequestDto dto)
        {
            if (dto == null) return null;
            return new IdentityUser()
            {
                UserName = dto.Username,
                Email = dto.Username
            };
        }
    }
}