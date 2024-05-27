﻿using AutoMapper;
using AIO.Contracts.DTOs.Getter.Locations;
using AIO.Contracts.DTOs.Setter.Locations;
using AIO.Contracts.Filters.Auth;
using AIO.Core.IServices.Custom;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using NetTopologySuite.Geometries;

namespace AIO.Application.Helpers
{
    public partial class MappingProfile : Profile
    {
        private readonly IServer _server;
        private readonly IUnitOfWork _unitOfWork;
        public MappingProfile(IServer server, IUnitOfWork unitOfWork)
        {
            _server = server;
            _unitOfWork = unitOfWork;

            ElementMappingProfile();

            FileLibraryMappingProfile();

            LanguageMappingProfile();

            UserMappingProfile();

            RoleMappingProfile();

            PermissionMappingProfile();

            DepartmentMappingProfile();

            AppSettingMappingProfile();

            ProjectMappingProfile();

            ProjectPaymentMethodMappingProfile();
            ProjectInsuranceMappingProfile();
        }

        public int getRoleUserCount(string roleId)
        {
            var userRoleFilter = new UserRoleFilter() { RoleId = roleId };
            var query = _unitOfWork.UserRoles.buildUserRoleQuery(userRoleFilter);
            return query.Count();
        }

        public string buildPath(string path)
        {
            var adresses = _server.Features.Get<IServerAddressesFeature>().Addresses.ToList<string>();
            if (!string.IsNullOrEmpty(path))
            {
                var uri = path.Replace(@"\", @"/");
                if (adresses is not null && adresses.Count > 0)
                {
                    return $"{adresses[0]}{uri}";
                }
                return uri;
            }
            else
                return $"{adresses[0]}/Images/NoImage.jpg";
        }
        public string buildProfileImagePath(string path)
        {
            var adresses = _server.Features.Get<IServerAddressesFeature>().Addresses.ToList<string>();
            if (!string.IsNullOrEmpty(path))
            {
                var uri = path.Replace(@"\", @"/");
                if (adresses is not null && adresses.Count > 0)
                {
                    return $"{adresses[0]}{uri}";
                }
                return uri;
            }
            else
                return $"{adresses[0]}/Images/NoProfile.png";
        }

        public DateTime? ToDateTime(string dateOnly)
        {
            try
            {
                if (!string.IsNullOrEmpty(dateOnly))
                    return DateTime.Parse(dateOnly);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TimeSpan? ToTimeSpan(string timeOnly)
        {
            try
            {
                if (!string.IsNullOrEmpty(timeOnly))
                    return TimeSpan.Parse(timeOnly);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ToDateOnly(DateTime? dateTime)
        {
            try
            {
                return dateTime?.ToString("dd-MM-yyyy");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ToTimeOnly(TimeSpan? timeSpan)
        {
            try
            {
                return timeSpan?.ToString(@"hh\:mm");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Point MapToPoint(LocationSetterDTO locationSetterDTO)
        {
            if (locationSetterDTO is not null)
            {
                var location = new Point(locationSetterDTO.Longitude, locationSetterDTO.Latitude);
                location.SRID = 4326;
                return location;
            }
            return null;
        }

        public LocationGetterDTO MapToLocationDTO(Point point)
        {
            if (point is not null)
            {
                return new LocationGetterDTO() { Longitude = point.X, Latitude = point.Y };
            }
            return null;
        }


    }
}