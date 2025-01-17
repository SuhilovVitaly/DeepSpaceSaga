﻿namespace DeepSpaceSaga.Common.Universe.Equipment;

public interface IModule : ICoreItem
{
    long TargetId { get; set; }       
    bool IsAutoRun { get; set; }
    bool IsCalculated { get; set; }
    double ActivationCost { get; set; }
    bool IsActive { get; set; }
    /// <summary>
    /// Fitting - Compartment number
    /// </summary>
    int Compartment { get; set; }
    /// <summary>
    /// Fitting - Slot position
    /// </summary>
    int Slot { get; set; }

    #region Reloading
    int LastReloadTurn { get; set; }
    bool IsReloaded { get; set; }
    double ReloadTime { get; set; }
    double Reloading { get; set; }

    #endregion

    void Reload(double progress, int turn = 0);

    void Execute();
}
