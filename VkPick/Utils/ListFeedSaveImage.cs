using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkPick.Utils
{
    class ListFeedSaveImage
    {
        private List<ListSavaImageUser> _listSavaImageUsers = new List<ListSavaImageUser>();
        private List<Photo> _listPhotoInProcess = new List<Photo>();
        private ushort? _count = 5;
        public ListFeedSaveImage(List<long> listUsersId)
        {
            foreach (var id in listUsersId)
            {
                var userSave = new ListSavaImageUser(id, _count);
                _listSavaImageUsers.Add(userSave);
                _listPhotoInProcess.Add(userSave.getLastPhoto());
            }
            
        }

        private List<Photo> fillListPhotos()
        {
            List < Photo > tempPhotos = new List<Photo>();
            while (tempPhotos.Count<_count)
            {
                var photo = _listPhotoInProcess.First(x => x.CreateTime== _listPhotoInProcess.Max(f=>f.CreateTime));
                int position = _listPhotoInProcess.IndexOf(photo);
                _listPhotoInProcess.Remove(photo);
                tempPhotos.Add(photo);
                _listPhotoInProcess.Insert(position,_listSavaImageUsers[position].getLastPhoto());
            }

            return tempPhotos;
        }
        public List<Photo> GetPhotos()
        {
            return fillListPhotos();
        }

        public class ListSavaImageUser
        {
            private int numGetPhoto = 0;
            private ulong? numChangeListPhotos = 1;
            private ulong? _count;
            private long _idUser;
            private VkCollection<Photo> _listPhotos;

            public ListSavaImageUser(long idUser, ulong? count)
            {
                this._idUser = idUser;
                _count = count;
                _listPhotos = getListPhotos(_count, 0, idUser);
            }

            public Photo getLastPhoto()
            {
                var photo = _listPhotos[numGetPhoto];
                numGetPhoto++;
                if ((ulong) (numGetPhoto + 1) == _count)
                {
                    numGetPhoto = 0;
                    numChangeListPhotos++;
                    _listPhotos = getListPhotos(_count, numChangeListPhotos * _count, _idUser);
                }

                return photo;
            }

            private VkCollection<Photo> getListPhotos(ulong? count, ulong? offset, long ownedId)
            {
                return Api.GetInstance().Photo.Get(new PhotoGetParams()
                {
                    AlbumId = PhotoAlbumType.Saved,
                    Offset = offset,
                    Count = count,
                    Reversed = true,
                    OwnerId = ownedId
                });
            }
        }
    }
}