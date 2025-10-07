﻿using FluentMigrator;

namespace NvsFood.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_USER, "Create table to save the users information")]
public class Version0000001 : VersionBase
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable();
    }
}