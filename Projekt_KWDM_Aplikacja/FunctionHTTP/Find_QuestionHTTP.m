function [Finded] = Find_QuestionHTTP()
%FIND_QUESTIONHTTP Summary of this function goes here
%   Detailed explanation goes here

url = 'http://localhost:5001/api/v1/Pacs/Find';
options = weboptions('RequestMethod', 'get');
Finded = webread(url, options);

end

