﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Innovator.Client
{
  public class ExplicitCredentials : INetCredentials
  {
    private string _database;
    private SecureToken _password;
    private string _username;

#if NET4
    public System.Net.ICredentials Credentials { get { return new NetworkCredential(_username, _password); } }
#else
    public System.Net.ICredentials Credentials { get { return new NetworkCredential(_username
      , _password.UseString((ref string s) => new string(s.ToCharArray()))); } }
#endif
    public string Database { get { return _database; } }
    public SecureToken Password { get { return _password; } }
    public string Username { get { return _username; } }

    public ExplicitCredentials(string database, string username, SecureToken password)
    {
      _database = database;
      _username = username;
      _password = password;
    }
  }
}
