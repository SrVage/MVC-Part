using System;
using System.Collections.Generic;
using Code.BonusGame.View;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.BonusGame.Model
{
    public class CellFactory
    {
        private List<Sprite> _cell;
        private byte[,] _cells = new byte[100, 100];

        public CellFactory(List<Sprite> cell)
        {
            _cell = cell;
            
            CreateEmptyCell();
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    _cells[i, j] = Index();
                }
            }
            CreateCell();
        }

        private byte Index()
        {
            byte a = Convert.ToByte(Random.Range(0, 100));
            if (a >= 0 && a < 31) return 1;
            if (a >= 31 && a < 51) return 2;
            if (a >= 51 && a < 66) return 3;
            if (a >= 66 && a < 76) return 4;
            if (a >= 76 && a < 85) return 5;
            if (a >= 85 && a < 93) return 6;
            else return 7;
        }

        public byte[,] Cells()
        {
            return _cells;
        }
        
        private void CreateCell()
        {
            var parent = GameObject.Find("cell");
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var cell = new GameObject("cell-"+i+"-"+j).AddComponent<SpriteRenderer>();
                    cell.GetComponent<SpriteRenderer>().sprite = _cell[_cells[i, j]];
                    cell.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
                    cell.transform.position = new UnityEngine.Vector3(i, j, -2);
                    cell.transform.localScale = new UnityEngine.Vector3(0.4f, 0.4f, 1);
                    cell.gameObject.tag = "Cell";
                    cell.transform.parent = parent.transform;
                }
            }
        }
        private void CreateEmptyCell()
        {
            var parent = GameObject.Find("emptycell");
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var cell = new GameObject("cell").AddComponent<SpriteRenderer>();
                    cell.GetComponent<SpriteRenderer>().sprite = _cell[0];
                    cell.transform.position = new UnityEngine.Vector3(i, j, 1);
                    cell.transform.localScale = new UnityEngine.Vector3(0.4f, 0.4f, 1);
                    cell.transform.parent = parent.transform;
                }
            }
        }
    }
}