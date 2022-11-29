using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public enum CellStatus
    {
        Alive,
        Dead
    }
    public enum Type
    {
        Classic_Cell
    }
    internal interface ICellable
    {
        Type GetCellType();
        void SetCellType(Type type);
        CellStatus GetCellStatus();
        void SetCellStatus(CellStatus cellStatus); 
        int GetCellsNearby();
        void SetCellsNearby(int amount);


    }
    public abstract class ACell: ICellable
    {
        private Type type;
        private CellStatus status;
        private int CellsNearby;
        public Type GetCellType()
        {
            return this.type;
        }
        public void SetCellType(Type type)
        {
            this.type = type;
        }
        public virtual int GetCellsNearby()
        {
            return CellsNearby;
        }
        public virtual void SetCellsNearby(int amount) {
            if (amount > 0 && amount <= 8) this.CellsNearby = amount;
            else this.CellsNearby = 0;
        }
        public virtual CellStatus GetCellStatus()
        {
            return this.status;
        }
        public virtual void SetCellStatus(CellStatus status)
        {
            this.status = status;
        }
    }
    public class ClassicCell: ACell
    {
        Type type = Type.Classic_Cell;
    }
}
