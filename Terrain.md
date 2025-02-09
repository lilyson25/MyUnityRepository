# **Unity Terrain 

### 1.2 **Terrain 생성**  
- `Hierarchy` 창에서 `Right Click` → `3D Object` → `Terrain` 추가  
- `Inspector` 창에서 `Terrain` 컴포넌트 조정  

---

## **2. Terrain 기본 설정**  
### 2.1 **Terrain 크기 조정**  
- `Inspector` → `Terrain Settings` → `Mesh Resolution` 설정  
- 기본 크기: `1000 x 1000 (Width x Length)`, 높이(`Height`)는 `600` 정도 추천  

### 2.2 **Terrain Tools 패키지 설치** *(선택 사항)*  
- `Window` → `Package Manager` → `Unity Registry`에서 `Terrain Tools` 검색 후 설치  
- Terrain 조작 도구를 추가로 활용 가능  

---

## **3. Terrain 조작하기**  
### 3.1 **지형 편집**  
- `Inspector` → `Paint Terrain` → `Raise/Lower Terrain` 선택  
- 마우스로 클릭하여 지형을 올리거나 내림  
- `Brush Size`와 `Opacity` 조절하여 자연스럽게 만들기  

### 3.2 **부드러운 지형 만들기**  
- `Smooth Height` 도구를 사용해 울퉁불퉁한 지형 부드럽게 다듬기  

### 3.3 **산, 언덕, 계곡 만들기**  
- `Raise/Lower Terrain`으로 산을 만들고 `Smooth Height`로 자연스럽게 조정  
- `Set Height` 도구를 활용하여 특정 높이로 평평한 땅 만들기  

---

## **4. 텍스처 적용**  
### 4.1 **Terrain에 텍스처 추가**  
- `Inspector` → `Paint Terrain` → `Paint Texture` 선택  
- `Edit Terrain Layers` → `Create Layer` 클릭  
- 기본 제공되는 `Terrain Layers`를 선택하거나 직접 텍스처 추가  

### 4.2 **다양한 텍스처 활용**  
- 산에는 바위 텍스처, 평지는 잔디 텍스처 적용  
- `Brush Opacity`를 조절하여 자연스럽게 섞기  

---

## **5. 자연 요소 추가**  
### 5.1 **나무(Tree) 배치**  
- `Inspector` → `Paint Terrain` → `Paint Trees`  
- `Edit Trees` → `Add Tree` → `Tree Prefab` 추가  
- `Brush Size` 및 `Tree Density` 조절하여 배치  

### 5.2 **풀(Grass) 배치**  
- `Inspector` → `Paint Terrain` → `Paint Details`  
- `Edit Details` → `Add Grass Texture`  
- `Brush Strength` 조절하여 자연스럽게 배치  

---

## **6. 환경 설정**  
### 6.1 **Directional Light 설정**  
- `Lighting` 창(`Window` → `Rendering` → `Lighting`)에서 `Sun Source` 설정  
- `Directional Light`의 각도 조정하여 낮/저녁 분위기 연출  

### 6.2 **Skybox 변경**  
- `Window` → `Rendering` → `Lighting` → `Environment`  
- `Skybox Material`에서 원하는 하늘 선택  

### 6.3 **Fog(안개) 효과 추가**  
- `Lighting` → `Fog` 활성화  
- `Color`와 `Density` 조절하여 분위기 연출  

---
