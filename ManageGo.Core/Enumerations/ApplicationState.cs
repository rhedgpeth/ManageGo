using System;

namespace ManageGo.Core.Enumerations
{
	/// <summary>
    /// Application state enum, mapped to UIApplicationState
    /// </summary>
    public enum ApplicationState : long
    {
        Active,
        Inactive,
        Background
    }
}
