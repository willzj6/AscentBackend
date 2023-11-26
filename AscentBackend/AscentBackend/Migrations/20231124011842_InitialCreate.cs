using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AscentBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewsPacks",
                columns: table => new
                {
                    packName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewsPacks", x => x.packName);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    streamName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.streamName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    candidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visaStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    streamName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.candidateId);
                    table.ForeignKey(
                        name: "FK_Candidates_Streams_streamName",
                        column: x => x.streamName,
                        principalTable: "Streams",
                        principalColumn: "streamName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewPackStream",
                columns: table => new
                {
                    interviewPackspackName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    streamsstreamName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewPackStream", x => new { x.interviewPackspackName, x.streamsstreamName });
                    table.ForeignKey(
                        name: "FK_InterviewPackStream_InterviewsPacks_interviewPackspackName",
                        column: x => x.interviewPackspackName,
                        principalTable: "InterviewsPacks",
                        principalColumn: "packName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewPackStream_Streams_streamsstreamName",
                        column: x => x.streamsstreamName,
                        principalTable: "Streams",
                        principalColumn: "streamName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentCenters",
                columns: table => new
                {
                    acId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentCenters", x => x.acId);
                    table.ForeignKey(
                        name: "FK_AssessmentCenters_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    availabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    availability = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.availabilityId);
                    table.ForeignKey(
                        name: "FK_Availabilities_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewPackUser",
                columns: table => new
                {
                    interviewPackspackName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    usersuserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewPackUser", x => new { x.interviewPackspackName, x.usersuserId });
                    table.ForeignKey(
                        name: "FK_InterviewPackUser_InterviewsPacks_interviewPackspackName",
                        column: x => x.interviewPackspackName,
                        principalTable: "InterviewsPacks",
                        principalColumn: "packName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewPackUser_Users_usersuserId",
                        column: x => x.usersuserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    interviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assessmeCenteracId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    candidateId = table.Column<int>(type: "int", nullable: false),
                    interviewPackpackName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.interviewId);
                    table.ForeignKey(
                        name: "FK_Interviews_AssessmentCenters_assessmeCenteracId",
                        column: x => x.assessmeCenteracId,
                        principalTable: "AssessmentCenters",
                        principalColumn: "acId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_Candidates_candidateId",
                        column: x => x.candidateId,
                        principalTable: "Candidates",
                        principalColumn: "candidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_InterviewsPacks_interviewPackpackName",
                        column: x => x.interviewPackpackName,
                        principalTable: "InterviewsPacks",
                        principalColumn: "packName");
                    table.ForeignKey(
                        name: "FK_Interviews_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentCenters_userId",
                table: "AssessmentCenters",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_userId",
                table: "Availabilities",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_streamName",
                table: "Candidates",
                column: "streamName");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewPackStream_streamsstreamName",
                table: "InterviewPackStream",
                column: "streamsstreamName");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewPackUser_usersuserId",
                table: "InterviewPackUser",
                column: "usersuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_assessmeCenteracId",
                table: "Interviews",
                column: "assessmeCenteracId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_candidateId",
                table: "Interviews",
                column: "candidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_interviewPackpackName",
                table: "Interviews",
                column: "interviewPackpackName");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_userId",
                table: "Interviews",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "InterviewPackStream");

            migrationBuilder.DropTable(
                name: "InterviewPackUser");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "AssessmentCenters");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "InterviewsPacks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Streams");
        }
    }
}
