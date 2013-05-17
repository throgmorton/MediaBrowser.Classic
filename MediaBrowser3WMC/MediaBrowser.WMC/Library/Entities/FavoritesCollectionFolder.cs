﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaBrowser.Model.Querying;

namespace MediaBrowser.Library.Entities
{
    public class FavoritesCollectionFolder : LocalIbnSourcedCacheFolder
    {
        public override bool AllowRemoteChildren
        {
            get
            {
                return false;
            }
        }

        public override string Name
        {
            get
            {
                return Kernel.Instance.ConfigData.FavoriteFolderName;
            }
            set
            {
                base.Name = value;
            }
        }

        protected override string DefaultPrimaryImagePath
        {
            get
            {
                return "resx://MediaBrowser/MediaBrowser.Resources/Favorites";
            }
        }

        protected override string RalParentId
        {
            get { return Kernel.Instance.RootFolder.ApiId; }
        }

        protected override ItemFilter[] AdditionalRalFilters
        {
            get
            {
                return new[] {ItemFilter.IsFavorite};
            }
        }

        public void Clear()
        {
            foreach (var child in Children.OfType<FavoritesTypeFolder>())
            {
                child.Clear();
            }
            OnChildrenChanged(null);
            OnQuickListChanged(null);
        }
    }
}
