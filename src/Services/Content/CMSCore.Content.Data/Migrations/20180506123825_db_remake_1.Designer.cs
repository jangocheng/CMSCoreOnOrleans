﻿// <auto-generated />
using System;
using CMSCore.Content.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CMSCore.Content.Data.Migrations
{
    [DbContext(typeof(ContentDbContext))]
    [Migration("20180506123825_db_remake_1")]
    partial class db_remake_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-preview2-30571");

            modelBuilder.Entity("CMSCore.Content.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("EntityId");

                    b.Property<string>("FeedItemId");

                    b.Property<string>("FullName");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("IsActiveVersion");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("FeedItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CMSCore.Content.Models.Feed", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("EntityId");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("IsActiveVersion");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("PageId");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("PageId")
                        .IsUnique();

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("CMSCore.Content.Models.FeedItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CommentsEnabled");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("EntityId");

                    b.Property<string>("FeedId");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("IsActiveVersion");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<string>("NormalizedTitle");

                    b.Property<string>("StaticContentId");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.HasIndex("StaticContentId");

                    b.ToTable("FeedItems");
                });

            modelBuilder.Entity("CMSCore.Content.Models.Page", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("EntityId");

                    b.Property<bool>("FeedEnabled");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("IsActiveVersion");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("StaticContentId");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("StaticContentId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("CMSCore.Content.Models.StaticContent", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("EntityId");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("IsActiveVersion");

                    b.Property<bool>("IsContentMarkdown");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.ToTable("StaticContents");
                });

            modelBuilder.Entity("CMSCore.Content.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("EntityId");

                    b.Property<string>("FeedItemId");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("IsActiveVersion");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("FeedItemId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CMSCore.Content.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("EntityId");

                    b.Property<string>("FirstName");

                    b.Property<bool>("Hidden");

                    b.Property<string>("IdentityUserId");

                    b.Property<bool>("IsActiveVersion");

                    b.Property<string>("LastName");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CMSCore.Content.Models.Comment", b =>
                {
                    b.HasOne("CMSCore.Content.Models.FeedItem")
                        .WithMany("Comments")
                        .HasForeignKey("FeedItemId");
                });

            modelBuilder.Entity("CMSCore.Content.Models.Feed", b =>
                {
                    b.HasOne("CMSCore.Content.Models.Page", "Page")
                        .WithOne("Feed")
                        .HasForeignKey("CMSCore.Content.Models.Feed", "PageId");
                });

            modelBuilder.Entity("CMSCore.Content.Models.FeedItem", b =>
                {
                    b.HasOne("CMSCore.Content.Models.Feed", "Feed")
                        .WithMany("FeedItems")
                        .HasForeignKey("FeedId");

                    b.HasOne("CMSCore.Content.Models.StaticContent", "StaticContent")
                        .WithMany()
                        .HasForeignKey("StaticContentId");
                });

            modelBuilder.Entity("CMSCore.Content.Models.Page", b =>
                {
                    b.HasOne("CMSCore.Content.Models.StaticContent", "StaticContent")
                        .WithMany()
                        .HasForeignKey("StaticContentId");
                });

            modelBuilder.Entity("CMSCore.Content.Models.Tag", b =>
                {
                    b.HasOne("CMSCore.Content.Models.FeedItem")
                        .WithMany("Tags")
                        .HasForeignKey("FeedItemId");
                });
#pragma warning restore 612, 618
        }
    }
}