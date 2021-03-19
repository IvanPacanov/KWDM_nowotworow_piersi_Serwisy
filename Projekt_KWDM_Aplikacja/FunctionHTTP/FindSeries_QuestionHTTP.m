function [Series] = FindSeries_QuestionHTTP(DicomInfo)
%FIND_SERIESHTTP Summary of this function goes here
%   Detailed explanation goes here
url = 'http://localhost:5001/api/v1/Pacs/FindSeries';
options = weboptions('RequestMethod', 'post');
Series = webwrite(url, DicomInfo, options);
end

