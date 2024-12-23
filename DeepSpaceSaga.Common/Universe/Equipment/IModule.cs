﻿namespace DeepSpaceSaga.Common.Universe.Equipment;

public interface IModule : ICoreItem
{
    long TargetId { get; set; }       
    bool IsAutoRun { get; set; }
    bool IsCalculated { get; set; }
    double ActivationCost { get; set; }

    /// <summary>
    /// Fitting - Compartment number
    /// </summary>
    int Compartment { get; set; }
    /// <summary>
    /// Fitting - Slot position
    /// </summary>
    int Slot { get; set; }

    #region Reloading

    bool IsReloaded { get; }
    double ReloadTime { get; set; }
    double Reloading { get; set; }

    #endregion

    void Reload();

    List<ISkill> Skills { get; set; }

    void AddSkill(ISkill skill);
}
