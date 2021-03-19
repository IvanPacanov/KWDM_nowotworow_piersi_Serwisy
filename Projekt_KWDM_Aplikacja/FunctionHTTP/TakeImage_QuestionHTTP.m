function [DicomInfoFile] = TakeImage_QuestionHTTP(DicomInfo)
%TAKEIMAGE_QUESTIONHTTP Summary of this function goes here
%   Detailed explanation goes here

url_Move = 'http://localhost:5001/api/v1/Pacs/Move';
options = weboptions('RequestMethod', 'post');
DicomInfoFile = webwrite(url_Move, DicomInfo, options);
end

