﻿namespace GBSApi.Dtos.Account;

public class AuthNewUser
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
}