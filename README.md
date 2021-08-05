# MayvueAssessment
 Mid / Senior Software Dev Assessment for Mayvue


Hey, Firstly, thanks for taking the time to look at my assessment.  Secondly, It doesn't (probably) work.  I did what I would call the large majority and then ran out of time with 2 hangups.  

The first problem is that I never managed to get a SQL Server running on my computer (some SQL system32 / register files are borked).  I spent a long time hoping that wasn't the problem, but I was unable to host it on my own machine and I got my hands on another computer too late.  Unfortunate.  The actual SQL queries are there, and they should work (assuming correct connection values are put in) but they are untested.

The second problem is CORS between the Vue Frontend and the C/# API.  This one frustrated me a lot because I'm sure the solution is very simple and quick, but I didn't figure it out in time.  If it were .NET 4.0 or later, there are a few tools I'd use - like Access-Control-Allow-Origin or the Register method - but as of now it doesn't work.  I'm not even really sure why, the windows documentation (https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.0) for 3.0 seems to suggest what I did would be fine, but it just isn't cooperating.  Again, unfortunate that I ran out of time.  The API takes and recieves commands correctly from Postman, and the Vue Frontend is sending crud correctly, but the connection is just not there.

The Vue Production files are in the "dist" folder, the C# .exe is ./CSharpAPI/MayvueMotionPictures/bin/Debug/netcoreapp3.1/MayvueMotionPictures.exe.  Right now, the SQL connection server name is (local).  The query to create and populate a sample database is ./CSharpAPI/MayvueMotionPictures/CreateMPDB.sql.

I used a naive Quick Sort for sorting the table, I like stable sorts for this kind of thing and adding rand would probably slow it down more than any potential time savings, that would obviously be capped by pushing that to the SQL Server and just having the data be ordered in a way.  It is recursive, and it should be iterative for space complexity considerations, I just ran out of time. 
The table should be updated from the database with each crud request, which would be a problem were the data to be large.  If it were, I would choose to sort the data server-side and then paginate it to cut loading times.
The CompareMovies method in the Vue Table is designed more for readability than function. It is a lot slower than sorting through an Enum for the right comparison, but it should only have to check the first char of the strings unless columns were added to the table that matched many first chars (eg. Release Rating).

For BONUS POINTS, the sorts all work, modals are used, and confirmation is required for deleting records. 

Again, thanks for going over my assessment, I wish I had more time to finish it but life got in the way a little. 

Appreciate the consideration,
    -Matt
