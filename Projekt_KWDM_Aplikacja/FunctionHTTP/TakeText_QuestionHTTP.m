function [text] = TakeText_QuestionHTTP(name)
%TAKETEXT Summary of this function goes here
%   Detailed explanation goes here
textin.text = "";
textin.name = string(name);
url = 'http://localhost:5001/api/v1/Pacs/TakeFile';
options = weboptions('RequestMethod', 'post');
text = webwrite(url, textin, options);
end

