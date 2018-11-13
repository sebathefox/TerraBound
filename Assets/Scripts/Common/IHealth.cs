using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Common
{
    public interface IHealth
    {
        int Health { get; }

        int GetMaxHp();

        void TakeDamage(double damage);

        void AddHp(int hp);

        void SetHp(int hp);

        void SubtractHp(int hp);
    }
}
