using FluentMigrator;

namespace NvsFood.Infrastructure.Migrations.Versions;

public abstract class VersionBase : ForwardOnlyMigration
{
    protected void CreateTable(string table)
    {
        Create.Table(table)
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithColumn("Active").AsBoolean().NotNullable();
    }
}