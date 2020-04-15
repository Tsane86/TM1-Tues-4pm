CREATE TABLE User (
    EmailAddress VARCHAR(30) NOT NULL,
    FirstName VARCHAR(20),
    LastName VARCHAR(20),
    DOB DATE,
    StreetNo VARCHAR(5),
    Address VARCHAR(40),
    Suburb VARCHAR(20),
    State VARCHAR(3),
    Postcode VARCHAR(4),
    UserPassword VARCHAR(20),
    CONSTRAINT User_PK PRIMARY KEY (EmailAddress),
    CONSTRAINT State_Lim CHECK (State = 'NSW' OR State = 'VIC' OR State = 'SA' OR State = 'TAS' OR State = 'QLD' OR State = 'NT' OR State = 'WA' OR State = 'ACT'),
    CONSTRAINT Postcode_Lim CHECK (LENGTH(Postcode) = 4)
);

CREATE TABLE Paitent (
    EmailAddress VARCHAR(30) NOT NULL,
    MedicareNo VARCHAR(8),
    CONSTRAINT Paitent_PK PRIMARY KEY (EmailAddress),
    CONSTRAINT Paitent_FK FOREIGN KEY (EmailAddress) REFERENCES User (EmailAddress)
);

CREATE TABLE Doctor (
    EmailAddress VARCHAR(30) NOT NULL,
    DoctorID VARCHAR(15),
    Speciality VARCHAR(15),
    MedicalCentre VARCHAR(20),
    CONSTRAINT Doctor_PK PRIMARY KEY (EmailAddress),
    CONSTRAINT Doctor_FK FOREIGN KEY (EmailAddress) REFERENCES User (EmailAddress)
);