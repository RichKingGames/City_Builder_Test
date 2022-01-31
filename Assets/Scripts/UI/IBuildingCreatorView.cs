using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingCreatorView
{
    IBuildingCreatorController Controller { set; }
    bool MenuIsOpen();
}
