function [image] = DecodeImage(ZdjecieHTTP)
%DECODEIMAGE Summary of this function goes here
%   Detailed explanation goes here


 base64 = org.apache.commons.codec.binary.Base64();
           unicode2native(ZdjecieHTTP,'UTF-8');
           img_bytes = base64.decode(unicode2native(ZdjecieHTTP,'UTF-8'));
            
            % Fill a temporary file with the decoded byte array...
            fid = fopen('dicomek.dcm','w');
            fwrite(fid,img_bytes,'int8');
            fclose(fid);
            
            % Read the temporary file as image and show the image...
            info = dicominfo('dicomek.dcm');
            %delete('dicomek.dcm')

           % app.image1=dicom2image(app.image1,'jpg');
           full_file = info.Filename;
           image = dicomread(full_file);
           % the name for your image after convertion.
            image = imresize(image,[256 256]); 
          

end

