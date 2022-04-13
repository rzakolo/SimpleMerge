using UnityEngine;
internal class Compare
{
    public bool Equals(Potion potion1, Potion potion2)
    {
        if (potion1.Name == potion2.Name && potion1.Grade == potion2.Grade)
        {
            return true;
        }
        return false;
    }
}

