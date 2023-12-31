﻿using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Framework;
using MediatR;

namespace CourseWebApi.Model.Auth.Queries
{
    public class TokenQueriy : IRequest<ApiResult<TokenModel>>
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
