function [Y] = SegmentationImage2(PreProcessedImage)
        Y=double(PreProcessedImage);

        k=2; % k: number of regions

        g=2; % g: number of GMM components

        beta=1; % beta: unitary vs. pairwise

        EM_iter=10; % max num of iterations

        MAP_iter=10; % max num of iterations

       % fprintf('Performing k-means segmentation\n');

        [X,GMM,ShapeTexture]=image_kmeans(Y,k,g);
        [X,Y,GMM]=HMRF_EM(X,Y,GMM,k,g,EM_iter,MAP_iter,beta);

        Y=Y*80;

        Y=uint8(Y);
 %OutImage=Y;


        
        Y=im2gray(Y);
    Y=double(Y);
    
    statsa = glcm(Y,0,ShapeTexture);
    ExtractedFeatures1=statsa;

Y=uint8(Y);

end

