function [Studies] = FindStudy_QuestionHTTP(DicomInfo)
%FIND_STUDYHTTP Summary of this function goes here
%   Detailed explanation goes here

url = 'http://localhost:5001/api/v1/Pacs/FindStudy';
options = weboptions('RequestMethod', 'post');
Studies = webwrite(url, DicomInfo, options);


end

