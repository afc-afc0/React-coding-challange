import React, { useState, useRef, useEffect, useCallback } from 'react';
import useInView from 'react-cool-inview'
import Gallery from 'react-photo-gallery'
import Modal from 'react-modal'
import Image from 'next/image'
import { v4 as uuidv4 } from 'uuid'
import { getImages } from '../api/apiCalls';

const customModalStyle = {
  content: {
    top: '50%',
    left: '50%',
    right: 'auto',
    bottom: 'auto',
    marginRight: '-50%',
    transform: 'translate(-50%, -50%)',
    maxHeight: '700px'
  },
};
  
//Binding modal to our app
Modal.setAppElement("#__next");

const ImageList = () => {
  const [images, setImages] = useState([]);
  const [currentImage, setCurrentImage] = useState({}); 
  const [modalIsOpen, setIsOpen] = useState(false);
  
  const loadImages = async () => {
    try {
      const response = await getImages();
      const newImages = [];
      response.data.forEach(image => {    
        newImages.push({
            key : uuidv4(),
            src : image.src,
            height : image.height,
            width : image.width,
            raw_image_src: image.rawImageUrl
        })
      });
      setImages(prevImages => [...prevImages, ...newImages]);
    } catch (error) {
      console.log(error);
    }
  };
  
  useEffect(async () => loadImages(), []);

  const { observe } = useInView({
      rootMargin: "50px 0px",
      // When the last item comes to the viewport
      onEnter: async ({ unobserve }) => {
          // Pause observe when loading the data 
          unobserve();
          // Load more data
          console.log("loading more data");
          await loadImages();
          observe();
      },
  });
  
  const openModal = useCallback((event, { photo, index }) => {
    setCurrentImage(photo);
    setIsOpen(true);
  }, []);

  const closeModal = () => {
    setIsOpen(false);
  }

  return (
    <div>
      {images[0] && <Gallery photos={images} direction={"column"} onClick={openModal} margin={5}/>}
      <Modal isOpen={modalIsOpen} onRequestClose={closeModal} style={customModalStyle}>
        <Image src={currentImage.raw_image_src} width={currentImage.width} height={currentImage.height} placeholder="blur" blurDataURL={currentImage.src}/>
      </Modal>
      <div ref={observe}></div>
    </div>
  );
};

export default ImageList;
