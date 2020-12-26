using System;

namespace AirMonitor.Domain.Installation.Dto
{
    public readonly struct InstallationAddressDto : IEquatable<InstallationAddressDto>
    {
        #region Fields

        public long InstallationId => _installationId;
        public string Country => _country;
        public string City => _city;
        public string Street => _street;
        public string Number => _number;
        public string DisplayAddress1 => _displayAddress1;
        public string DisplayAddress2 => _displayAddress2;

        private readonly long _installationId;
        private readonly string _country;
        private readonly string _city;
        private readonly string _street;
        private readonly string _number;
        private readonly string _displayAddress1;
        private readonly string _displayAddress2;

        #endregion

        #region Constructors

        private InstallationAddressDto(long installationId,
                                       string country,
                                       string city,
                                       string street,
                                       string number,
                                       string displayAddress1,
                                       string displayAddress2)
        {
            _installationId = installationId;
            _country = country;
            _city = city;
            _street = street;
            _number = number;
            _displayAddress1 = displayAddress1;
            _displayAddress2 = displayAddress2;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(InstallationAddressDto other)
            => _installationId == other._installationId
            && _country == other._country
            && _city == other._city
            && _street == other._street
            && _number == other._number
            && _displayAddress1 == other._displayAddress1
            && _displayAddress2 == other._displayAddress2;

        public override bool Equals(object obj)
            => obj is InstallationAddressDto other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(_installationId, _country, _city, _street, _number, _displayAddress1, _displayAddress2);

        #endregion

        #region StaticConstructors

        public static InstallationAddressDto FromDomain(InstallationAddress domain)
            => new InstallationAddressDto(domain.InstallationId ?? throw new ArgumentException("InstallationId is null"),
                                          domain.Country,
                                          domain.City,
                                          domain.Street,
                                          domain.Number,
                                          domain.DisplayAddress1,
                                          domain.DisplayAddress2);

        #endregion
    }
}