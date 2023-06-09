﻿using System.Text.RegularExpressions;
using Domain.Exceptions;

namespace Domain.ValueObjects.Commons;

public readonly partial struct EmailAddress
{
   private static readonly Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3}){1,})$");

   public static bool IsValid(string value)
   {
      return EmailRegex.IsMatch(value);
   }
   
   private string Value { get; init; }

   public EmailAddress(string value)
   {
      if (!IsValid(value))
      {
         throw new InvalidEmailAddressException("invalid email address");
      }
      Value = value;
   }

   public static explicit operator string(EmailAddress email)
   {
      return email.Value;
   }
   
   public static explicit operator EmailAddress(string emailString)
   {
      return new EmailAddress(emailString);
   }
}