import React, { useState, useRef, useEffect, useCallback } from 'react';
import useInView from 'react-cool-inview'
import Gallery from 'react-photo-gallery'
import Modal from 'react-modal'
import { getImages } from '../api/apiCalls';


const ImageList = () => {
  const [images, setImages] = useState([]);
  const [currentImageSrc, setCurrentImageSrc] = useState(0); 
  const [modalIsOpen, setIsOpen] = useState(false);
  
  const loadImages = async () => {
    try {
      const response = await getImages();
      console.log(response.data); 
      const newImages = [];
      response.data.forEach(image => {
          newImages.push({
              src : image.src,
              height : image.height,
              width : image.width,
              rawSrc : image.rawImageUrl
          })
      });
      setImages(prevImages => [...prevImages, ...newImages]);
    } catch (error) {
      console.log(error);
    }
  };
  
  useEffect(async () => loadImages(), []);

//   const { observe } = useInView({
//       rootMargin: "50px 0px",
//       // When the last item comes to the viewport
//       onEnter: async ({ unobserve }) => {
//           // Pause observe when loading the data 
//           unobserve();
//           // Load more data
//           console.log("loading more data");
//           await loadImages();
//       },
//   });
  
  const openModal = useCallback((event, { photo, index }) => {
    setCurrentImageSrc(photo.rawSrc);
    setIsOpen(true);
  }, []);

  const closeModal = () => {
    setCurrentImageSrc("");
    setIsOpen(false);
  }

  return (
    <div>
      {images[0] && <Gallery photos={images} direction={"column"} onClick={openModal}/>}
      <Modal isOpen={modalIsOpen} onRequestClose={closeModal}>
        <img src={currentImageSrc} />
      </Modal>
    </div>
  );
};

export default ImageList;
