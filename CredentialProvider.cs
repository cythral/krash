using System;

namespace krash {
    class CredentialProvider {
        static public string githubToken {
            get {
                return Environment.GetEnvironmentVariable("KRASH_GITHUB_TOKEN");
            }
        }
    }
}