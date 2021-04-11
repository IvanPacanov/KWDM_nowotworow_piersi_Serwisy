function SaveToFile_QuestionHTTP(text, name)
%SAVETOFILE_QUESTIONHTTP Summary of this function goes here
%   Detailed explanation goes here
textin.text = string(text);
textin.name = string(name);

url = 'http://localhost:5001/api/v1/Pacs/SaveToFile';
options = weboptions('RequestMethod', 'post');
webwrite(url, textin, options);
end
