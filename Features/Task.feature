Feature: Upload, Metadata, Delete

@Task 
Scenario: Upload, Metadata, Delete
Given folder "/files" exists
When upload file "file.txt"
And get metadata of "file.txt"
And delete "file.txt"
