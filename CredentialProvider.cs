using System;

namespace krash {
    class CredentialProvider {
        static public string githubToken {
            get {
                return Environment.GetEnvironmentVariable("KRASH_GITHUB_TOKEN");
            }
        }

        static public string githubUser {
            get {
                return Environment.GetEnvironmentVariable("KRASH_GITHUB_USER");
            }
        }
    }
}