# WordVenture

**Team 6203**의 GIGDC 2024 출품작 워드의 모험(WordVenture)(가칭) 제작을 위한 저장소입니다. 여기는 Main!

[대회 설명](https://www.gigdc.or.kr/sub01/sub02.php)


## 이렇게 사용하세요.

1. 기능을 추가하려면 기능별 브랜치를 만들어서 작업해주세요.
2. 작업이 끝났다면 본인 브랜치에 develop 브랜치를 먼저 병합하고, 오류가 있다면 오류를 해결해주세요.
3. 문제가 다 해결되었다면, develop 브랜치에 병합해주세요.
4. 하나의 버전이 병합 후 안정적으로 완성이 되었다면, 메인 브랜치에 병합해주세요.

## 이렇게 정리합시다.
1. 본인의 폴더를 만들어서 스크립트나 리소스를 정리합시다.

## 이렇게 코딩합시다.

1. 네임스페이스 적용해서 본인 코드 짜기
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBattle
{
    public class TurnBattleSystem : MonoBehaviour
    {
      ...
    }

}

다른 네임스페이스 참조하려면 using TurnBattle; 사용! 

```   
2. [C# Naming Convention](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations) 를 참조하여 이름을 정해봅시다.

3. [UML Diagram](https://velog.io/@jungmyeong96/UML-다이어그램-작성법) 을 참조하여 본인이 작성한 코드를 정리해봅시다. 협업할 때 이해가 잘 되고 피드백도 수월해질 것 입니다.
