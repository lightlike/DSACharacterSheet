﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Drachenhorn.Map.BSPT;
using Drachenhorn.Map.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Drachenhorn.Core.ViewModels.Common
{
    public class MapViewModel : ViewModelBase
    {
        #region Properties

        private List<List<TileType>> _grid;

        public List<List<TileType>> Grid
        {
            get { return _grid; }
            set
            {
                if (_grid == value)
                    return;
                _grid = value;
                RaisePropertyChanged();
            }
        }

        #endregion Properties


        #region c'tor

        public MapViewModel()
        {
            InitializeCommands();
        }

        #endregion c'tor


        #region Commands

        private void InitializeCommands()
        {
            Generate = new RelayCommand(ExecuteGenerate);
        }

        public RelayCommand Generate { get; private set; }

        private void ExecuteGenerate()
        {
            var grid = LeafGenerator.GenerateLeaf();
            List<List<TileType>> result = new List<List<TileType>>();


            for (int i = 0; i < grid.GetLength(1); ++i)
            {
                var temp = new List<TileType>();
                for (int j = 0; j < grid.GetLength(0); ++j)
                {
                    temp.Add(grid[j,i]);
                }

                result.Add(temp);
            }

            Grid = result;
        }

        #endregion Commands
    }
}
