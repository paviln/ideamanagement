# ideamanagement

If the Program wont run. Update your Visual Studio to the latest update to be fully compatible with dotnet 5.0. 

If the Program wont run because of SSL handshake fail. Try and run the following in the terminal:

dotnet dev-certs http --clean
dotnet dev-certs https --trust

If the database is not updated run this command in the terminal:

dotnet ef update database

If the website doesn't load react, reinstall npm.
under API run npm install
